/*
 * 
 * 
 * //dependency injection
IChirurgienService cs;
public ChirurgienController(IChirurgienService cs)
{
    this.cs = cs;
}

//POST
//file upload : dans Post
public ActionResult Create(Equipe collection, IFormFile file)
//image upload
                collection.Logo = file.FileName;
if (file != null)
{
    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
   file.FileName);
    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
    {
        file.CopyTo(stream);
    }
}
//html
< form asp - action = "Create" enctype = "multipart/form-data" >
    < div class= "form-group" >
        < label asp -for= "Logo" class= "control-label" ></ label >  
        < input type = "file" name = "file" class= "form-control" />      
        < span asp - validation -for= "Logo" class= "text-danger" ></ span >
    </ div >
    < span asp - validation -for= "Logo" class= "text-danger" ></ span >
</form>

//filter
[HttpPost]
        public ActionResult Index(string filter)
{
    var list = es.GetMany();
    if (!String.IsNullOrEmpty(filter))
    {
        return View(es.GetMany(e => e.NomEquipe.Contains(filter)));
    }
    return View(list);
}
//html
< fieldset >
  < legend > Search By:</ legend >
  < form asp - action = "index" >
     < label for= "filter" > Filter </ label >
     < input type = "text" name = "filter" />
     < input type = "submit" value = "Search" />
  </ form >
</ fieldset >




//simple add
se.Add(collection);
se.Commit();

//GET
//add list  deroulante
var equipes = es.GetMany();
ViewBag.EquipeFK = new SelectList(equipes, "EquipeId", "NomEquipe");



//startup
services
           .AddScoped<IOperationService, OperationService>()

           .AddTransient<IUnitOfWork, UnitOfWork>().
           AddScoped<IDataBaseFactory, DataBaseFactory>().
           BuildServiceProvider();
services.AddControllersWithViews();
*/