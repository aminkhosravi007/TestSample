using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestSample.Data;
using TestSample.Models;

namespace TestSample.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var blogPosts = await _context.BlogPosts
                .Include(bp => bp.Tags)
                .ToListAsync();
            return View(blogPosts);
        }
        public IActionResult Create()
        {
            //ViewBag.Tags = new SelectList(_context.Tags, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogPost blogPost, List<int> selectedTags)
        {
            if (ModelState.IsValid)
            {
                blogPost.Tags = await _context.Tags
                    .Where(tag => selectedTags.Contains(tag.Id))
                    .ToListAsync();

                blogPost.CreatedTime = DateTime.Now;

                _context.BlogPosts.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewBag.Tags = new SelectList(_context.Tags, "Id", "Name");
            return View(blogPost);
        }
        public IActionResult FilterByTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                var allPosts = _context.BlogPosts.Include(bp => bp.Tags).ToList();
                return PartialView("_BlogPostsTableRows", allPosts);
            }

            var filteredPosts = _context.BlogPosts
                .Where(bp => bp.Tags.Any(t => t.Name.Contains(tag)))
                .Include(bp => bp.Tags)
                .ToList();

            return PartialView("_BlogPostsTableRows", filteredPosts);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var blogPost = await _context.BlogPosts
                .Include(bp => bp.Tags)
                .FirstOrDefaultAsync(bp => bp.Id == id);

            if (blogPost == null) return NotFound();

            //ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name", blogPost.Tags.Select(t => t.Id));
            return View(blogPost);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BlogPost blogPost, List<int> selectedTags)
        {
            if (id != blogPost.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingPost = await _context.BlogPosts
                        .Include(bp => bp.Tags)
                        .FirstOrDefaultAsync(bp => bp.Id == id);

                    if (existingPost == null) return NotFound();

                    existingPost.Title = blogPost.Title;
                    existingPost.Content = blogPost.Content;

                    existingPost.Tags.Clear();
                    existingPost.Tags = await _context.Tags
                        .Where(tag => selectedTags.Contains(tag.Id))
                        .ToListAsync();

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id)) return NotFound();
                    else throw;
                }
            }

            //ViewBag.Tags = new SelectList(_context.Tags, "Id", "Name");
            return View(blogPost);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var blogPost = await _context.BlogPosts
                .Include(bp => bp.Tags)
                .FirstOrDefaultAsync(bp => bp.Id == id);

            if (blogPost == null) return NotFound();

            return View(blogPost);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts
                .Include(bp => bp.Tags)
                .FirstOrDefaultAsync(bp => bp.Id == id);

            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }


    }
}
