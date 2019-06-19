using System.Linq;
using DataContext.Data;
using DataContext.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly CaloriesContext _context;

        public RecipeController(CaloriesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new RecipeViewModel
            {
                Recipes = _context.Recipes.ToList()
            };
            
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new ManageRecipeViewModel
            {
                Recipe = new Recipe()
            };
            
            return View("Edit", model);
        }

        public IActionResult Edit(int recipeId)
        {
            var model = new ManageRecipeViewModel
            {
                Recipe = _context.Recipes.Single(r => r.Id == recipeId)
            };
            
            return View(model);
        }

        public IActionResult Store(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return RedirectToAction("Index","Recipe");
        }

        public IActionResult Delete(int recipeId)
        {
            _context.Recipes.Remove(_context.Recipes.Single(r => r.Id == recipeId));
            _context.SaveChanges();
            return RedirectToAction("Index", "Recipe");
        }

        public IActionResult Update(int recipeId, Recipe recipe)
        {
            var persistedRecipe = _context.Recipes.Single(r => r.Id == recipeId);
            persistedRecipe.Name = recipe.Name;
            _context.Recipes.Update(persistedRecipe);
            _context.SaveChanges();
            return RedirectToAction("Index", "Recipe");
        }
    }
}