using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test01.Data.Models.KB;

namespace Test01.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly KbDbContext _context;

        public TopicController(KbDbContext context)
        {
            _context = context;
        }

        // GET: Topic
        public async Task<IActionResult> Index()
        {
            var kbDbContext = _context
                                .Topic
                                .Where(t => t.IsVisible == true)
                                .OrderBy(t => t.Title)
                                .Take(30);
                ;
            return View(await kbDbContext.ToListAsync());
        }

        // GET: Topic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .Include(t => t.Product)
                .Include(t => t.Robot)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topic/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            ViewData["RobotId"] = new SelectList(_context.Robot, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Entity");
            return View();
        }

        // POST: Topic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,AliasUrl,StatusId,RobotId,IsVisible,CreatorId,RequestorId,AssigneeId,EditorId,PublishStart,PublishStop,ProductId,ValidProductStart,ValidProductStop,Content,MetaAuthor,MetaDescription,MetaKeywords,LastResolved,Deadline,Cuser,Cdate,Muser,Mdate,IsDeleted,AvgRating,NumViews,Contentastext,Featured")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", topic.ProductId);
            ViewData["RobotId"] = new SelectList(_context.Robot, "Id", "Id", topic.RobotId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Entity", topic.StatusId);
            return View(topic);
        }

        // GET: Topic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", topic.ProductId);
            ViewData["RobotId"] = new SelectList(_context.Robot, "Id", "Id", topic.RobotId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Entity", topic.StatusId);
            return View(topic);
        }

        // POST: Topic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AliasUrl,StatusId,RobotId,IsVisible,CreatorId,RequestorId,AssigneeId,EditorId,PublishStart,PublishStop,ProductId,ValidProductStart,ValidProductStop,Content,MetaAuthor,MetaDescription,MetaKeywords,LastResolved,Deadline,Cuser,Cdate,Muser,Mdate,IsDeleted,AvgRating,NumViews,Contentastext,Featured")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", topic.ProductId);
            ViewData["RobotId"] = new SelectList(_context.Robot, "Id", "Id", topic.RobotId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Entity", topic.StatusId);
            return View(topic);
        }

        // GET: Topic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .Include(t => t.Product)
                .Include(t => t.Robot)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            _context.Topic.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topic.Any(e => e.Id == id);
        }
    }
}
