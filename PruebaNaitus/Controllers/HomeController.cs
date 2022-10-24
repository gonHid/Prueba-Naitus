using Microsoft.AspNetCore.Mvc;
using Practice.DataAccess;
using Prueba_Naitus.Models;
using PruebaNaitus.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace PruebaNaitus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UsersController uc;
        private readonly testNaitusDBContext _context;


        public HomeController(ILogger<HomeController> logger, testNaitusDBContext context)
        {
            _logger = logger;
            _context = context;
            uc = new UsersController(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubirImagen(string rut , IFormFile image)
        {
           ImageFile tbl_News = new ImageFile();
            var user = await _context.Usuarios.FindAsync(rut);

            if (user == null)
            {
                return View("Index");
            }
            if (image != null)
            {

                //Set Key Name
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "img/"+rut, ImageName);

                System.IO.Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "img/"+rut));

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                ImageFile imgF = new ImageFile();
                imgF.Rut = user.Rut;
                imgF.FileName = ImageName;
                _context.Imagenes.Add(imgF);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                  
                   throw;
                   
                }


                return View();
            }
            else
            {
                return NotFound();
            }
            
        }
        public IActionResult Create(User user)
        {
            uc.PostUser(user);
            return View();
        }
        public IActionResult Listar()
        {
                var postsList = _context.Usuarios.Select(x => new User
                {
                   Rut = x.Rut,
                   Nombre = x.Nombre,
                   Apellido = x.Apellido,
                   Email = x.Email,
                   FechaNacimiento = x.FechaNacimiento,
                   Password = "*******"
                }).ToList();
                return View(postsList);
        }

        public async Task<IActionResult> Modificar(string Rut)
        {
            var user = await _context.Usuarios.FindAsync(Rut);

            if (user == null)
            {
              return View("Index"); ;
            }

            return View(user);
        }

        public async Task<IActionResult> Save(User user)
        {
            await uc.PutUser(user.Rut,user);
            return Index();
        }
     
        public async Task<IActionResult> Eliminar(string Rut)
        {
            var user = await _context.Usuarios.FindAsync(Rut);

            if (user == null)
            {
                return NotFound();
            }

            return View(user); return View();
        }

        public async Task<IActionResult> Deleted(string rut)
        {
            uc.DeleteUser(rut);
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}