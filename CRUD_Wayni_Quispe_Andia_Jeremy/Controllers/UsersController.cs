using CRUD_Wayni_Quispe_Andia_Jeremy.Infrastructure;
using CRUD_Wayni_Quispe_Andia_Jeremy.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Wayni_Quispe_Andia_Jeremy.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controlador para gestionar las operaciones CRUD de los usuarios.
/// </summary>
/// <author>Jeremy Quispe </author>
public class UsersController : Controller
{
    /// <summary>
    /// Contexto de la base de datos.
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor del controlador de usuarios.
    /// </summary>
    /// <param name="context">El contexto de la base de datos.</param>
    /// <author>Jeremy Quispe</author>
    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Muestra la lista de usuarios.
    /// </summary>
    /// <returns>Una vista con la lista de usuarios.</returns>
    /// <author>Jeremy Quispe</author>
    public async Task<IActionResult> Index()
    {
        return View(await _context.User.ToListAsync());
    }

    /// <summary>
    /// Muestra el formulario para crear un nuevo usuario.
    /// </summary>
    /// <returns>La vista para crear un usuario.</returns>
    /// <author>Jeremy Quispe</author>
    public IActionResult Crear()
    {
        return View();
    }

    /// <summary>
    /// Procesa los datos del formulario para crear un nuevo usuario.
    /// </summary>
    /// <param name="user">El usuario a crear.</param>
    /// <returns>Redirige al índice si tiene éxito; de lo contrario, muestra el formulario con errores.</returns>
    /// <author>Jeremy Quispe</author>
    [HttpPost]
    public IActionResult Crear(User user)
    {
        var existingUser = _context.User.FirstOrDefault(u => u.DNI == user.DNI);
        if (existingUser != null)
        {
            ModelState.AddModelError("DNI", "Ya existe un usuario con este DNI.");
            return View(user);
        }

        if (ModelState.IsValid)
        {
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }

    /// <summary>
    /// Muestra el formulario para editar un usuario existente.
    /// </summary>
    /// <param name="id">El ID del usuario a editar.</param>
    /// <returns>La vista para editar el usuario.</returns>
    /// <author>Jeremy Quispe</author>
    public async Task<IActionResult> Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.User.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    /// <summary>
    /// Procesa los datos del formulario para actualizar un usuario existente.
    /// </summary>
    /// <param name="id">El ID del usuario a editar.</param>
    /// <param name="user">Los datos actualizados del usuario.</param>
    /// <returns>Redirige al índice si tiene éxito; de lo contrario, muestra el formulario con errores.</returns>
    /// <author>Jeremy Quispe</author>
    [HttpPost]
    public async Task<IActionResult> Editar(int id, User user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        var existingUser = _context.User.FirstOrDefault(u => u.DNI == user.DNI && u.Id != user.Id);
        if (existingUser != null)
        {
            ModelState.AddModelError("DNI", "Ya existe otro usuario con este DNI.");
            return View(user);
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    /// <summary>
    /// Muestra la confirmación para eliminar un usuario.
    /// </summary>
    /// <param name="id">El ID del usuario a eliminar.</param>
    /// <returns>La vista de confirmación de eliminación.</returns>
    /// <author>Jeremy Quispe</author>
    public async Task<IActionResult> Eliminar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.User
            .FirstOrDefaultAsync(m => m.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    /// <summary>
    /// Procesa la confirmación para eliminar un usuario.
    /// </summary>
    /// <param name="id">El ID del usuario a eliminar.</param>
    /// <returns>Redirige al índice después de eliminar.</returns>
    /// <author>Jeremy Quispe</author>
    [HttpPost, ActionName("Eliminar")]
    public async Task<IActionResult> ConfirmarEliminar(int id)
    {
        var usuario = await _context.User.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        _context.User.Remove(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Verifica si un usuario existe en la base de datos.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    /// <returns>True si el usuario existe; de lo contrario, false.</returns>
    /// <author>Jeremy Quispe</author>
    private bool UsuarioExists(int id)
    {
        return _context.User.Any(e => e.Id == id);
    }
}
