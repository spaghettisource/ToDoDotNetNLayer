using AutoMapper;
using Core;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDoDotNet.Models;

namespace ToDoDotNet.Controllers
{
    public class ToDoController : BaseController
    {
        public IToDoRepository _toDoRepository { get; private set; }
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper { get; private set; }
        public ToDoController(
            IToDoRepository toDoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._toDoRepository = toDoRepository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        // GET: ToDo
        public async Task<ActionResult> Index(ToDoQueryResource query)
        {
            var filter = _mapper.Map<ToDoQueryResource, ToDoQuery>(query);
            var queryResult = await _toDoRepository.GetToDos(filter);

            return View(_mapper.Map<QueryResult<ToDo>, QueryResultResource<ToDoViewModel>>(queryResult));

        }

        // GET: ToDo/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                ToDo todo = new ToDo()
                {
                    Title = collection["Title"],
                    Body = collection["Body"],
                    CreationDate = System.DateTime.Now
                };

                _toDoRepository.Add(todo);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            var todo = await _toDoRepository.GetToDo(id);
            
            return View(todo);
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {               
                var todo = await _toDoRepository.GetToDo(id);

                if (todo == null)
                    return HttpNotFound();


                todo.Title = collection["Title"];
                todo.Body = collection["Body"];

                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


         // POST: ToDo/Delete/5
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var todo = await _toDoRepository.GetToDo(id);

                if (todo == null)
                    return HttpNotFound();

                _toDoRepository.Remove(todo);
                await _unitOfWork.CompleteAsync();

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            catch
            {
                return View();
            }
        }
    }
}
