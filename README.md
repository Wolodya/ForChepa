###ForChepa###

Для запуску необхідно змінити рядок підключення у кореневому WebConfig, а саме - ```connectionString="Data Source=(LocalDB)\MSSQLLocalDB;```.
В даному випадку, це підключення до MSSQL Server 2014. Для  MSSQL Server 2014 необхідно додати версію - ```connectionString="Data Source=(LocalDB))\v11.0\MSSQLLocalDB;```


**Опис виконання**

1) Створення моделей
- Клас таблиці *Cities*

 ```csharp 
 public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
```
- Клас таблиці *Countries*

```csharp 
public class Countries
   {        public int Id { get; set; }
        public string Name { get; set; }
   }
```

- Клас таблиці *Third*

```csharp
 public class Third
    {
        public int Id { get; set; }
       
        public Countries Countries { get; set; }
        public Cities Cities { get; set; }
        public int? CountriesId { get; set; }
        public int? CitiesId { get; set; }
    }
```

2) CRUD операції, фільтрація та pagination
Для кожної з моделей був створений контроллер з методами CRUD та відповідні представлення у View
Для pagination був завантажений плагін  **PagedList.Mvc**
Розглянемо на прикладі *Third* контроллера

Створення контексту - ```csharp TopographyContext tc = new TopographyContext();```

- Метод, що показує записи з таблиці

Параметри: номер сторінки, рядок-філтьтр та поточний фільтр для збереження запису в textBox
```csharp
 public ActionResult Index(int?page,string currentFilter,string filter)
        {
            if (filter!=null)
            {
                page = 1;
            }
            else
            {
                filter = currentFilter;
            }
            ViewBag.CurrentFilter = filter;
            var th = tc.Third.Include(city => city.Cities).Include(country => country.Countries);
            if (!String.IsNullOrEmpty(filter))
            {
                th = th.Where(f => f.Cities.Name.Contains(filter) || f.Countries.Name.Contains(filter));
            }
            int PageSize = 10;
            int PageNumber = (page ?? 1);
            return View(th.OrderBy(t=>t.Id).ToPagedList(PageNumber,PageSize));
        }
```
 Задання параметрів для pagination
 
 ```csharp int PageSize = 10;``` - кількість елементів для відображення на одній сторінці
```csharp return View(th.OrderBy(t=>t.Id).ToPagedList(PageNumber,PageSize));``` - OrderBy повинно передувати Skip та Take, що застосовуюься методом ToPagedList

Відповідно *Index* має вигляд 
```html
@using PagedList.Mvc
@model PagedList.IPagedList<ForChepa.Models.Third>
@{
    ViewBag.Title = "Third";
}

<h2>Third</h2>
<p>
    @Html.ActionLink("Add third", "Create")
</p>
@using (Html.BeginForm())
{
    <p>
        Filter : @Html.TextBox("filter",ViewBag.CurrentFilter as string)
        <input type="submit" value="Search" />
    </p>
}

<table>
    <tr>
        <th>Id</th>
        <th>Name Country</th>
        <th>Name City</th>
        <th></th>
    </tr>

    @foreach (var item in Model)
    {

        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Id)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Countries.Name)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Cities.Name)
            </td>
            <td>
                @Html.ActionLink("Редактировать", "Edit", new { id = item.Id }) 
                @Html.ActionLink("Удалить", "Delete", new { id = item.Id })
                @Html.ActionLink("Подробнее", "Details", new { id = item.Id })
            </td>
        </tr>
    }
</table>
<br/>
Page @(Model.PageCount<Model.PageNumber ?0:Model.PageNumber) of @Model.PageCount

@Html.PagedListPager(Model,page=>Url.Action("Index",new { page,currentFilter=ViewBag.CurrentFilter}))
```

Щоб побачити в дії перейдіть на вкладку Third

![index](https://github.com/Wolodya/ForChepa/blob/master/ForChepa/SnapShots/index.PNG)

- Для редагування натисніть *редактировать*. В випадаючому списку відобразяться старі значення.

![index](https://github.com/Wolodya/ForChepa/blob/master/ForChepa/SnapShots/edit.PNG)

Редагування здійснюється за допомогою 2 методів. Спочатку отримуємо відповідний запис, перевіряючи його наявність. Id отримуємо get'ом
```csharp
[HttpGet]
        public ActionResult Edit(int? id)
        {            if (id == null)
            {
                return HttpNotFound();
            }
            var th = tc.Third.Include(city => city.Cities).Include(country => country.Countries).FirstOrDefault(p => p.Id == id);
            if (th != null)
            {
                SelectList cities = new SelectList(tc.Cities, "Id", "Name");
                ViewBag.Cities = cities;
                SelectList countries = new SelectList(tc.Countries, "Id", "Name");
                ViewBag.Countries = countries;
                return View(th);
            }
            return RedirectToAction("Index");
        }
```
Потім Post'ом зберігаємо зміни
```csharp
[HttpPost]
        public ActionResult Edit(Third th)
        {
            tc.Entry(th).State = EntityState.Modified;
            tc.SaveChanges();
            return RedirectToAction("Index");
        }
```

- Для видалення, задля безпеки, аналогічно

```csharp
[HttpGet]
        public ActionResult Delete(int id)
        {
            Third th = tc.Third.Include(city => city.Cities).Include(country => country.Countries).FirstOrDefault(p => p.Id == id);
            if (th == null)
            {
                return HttpNotFound();
            }
            SelectList countries = new SelectList(tc.Countries, "Id", "Name");
            ViewBag.Countries = countries;
            SelectList cities = new SelectList(tc.Cities, "Id", "Name");
            ViewBag.Cities = cities;
            return View(th);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Third th = tc.Third.Find(id);
            if (th == null)
            {
                return HttpNotFound();
            }
            tc.Third.Remove(th);
            tc.SaveChanges();
            return RedirectToAction("Index");
        }
```

![index](https://github.com/Wolodya/ForChepa/blob/master/ForChepa/SnapShots/delete.PNG)
 
Для детального перегляду натисніть *подробнее*

![index](https://github.com/Wolodya/ForChepa/blob/master/ForChepa/SnapShots/read.PNG)

```csharp
public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Third th = tc.Third.Include(city => city.Cities).Include(country => country.Countries).FirstOrDefault(idd => idd.Id == id);
            
            if (th == null)
            {
                return HttpNotFound();
            }
          
            return View(th);
        }
```

Щоб додати запис натисніть *Add third*

![index](https://github.com/Wolodya/ForChepa/blob/master/ForChepa/SnapShots/add.PNG)

```csharp
  [HttpGet]
        public ActionResult Create()
        {
            SelectList cities = new SelectList(tc.Cities, "Id", "Name");
            SelectList countries = new SelectList(tc.Countries, "Id", "Name");
            ViewBag.Cities = cities;
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Third th)
        {
            tc.Third.Add(th);        
            tc.SaveChanges();
            return RedirectToAction("Index");
        }
```
В першому методі передаєтсья перелік міст та країн, а другий зберігає сам запис

Для фільтрації введіть назву міста або країни і натисніть *search*

![index](https://github.com/Wolodya/ForChepa/blob/master/ForChepa/SnapShots/filter.PNG)

3) Висновок

Для виконання 1 частини було витрачено 0.1 годин. 
Для виконання 2 витрачено 6 годин.

- Зроблено

1) Було виконано все відповідно до тз.

- Не зроблено

1) недоримання термінів. Причина - багато часу було витрачено на вивчення побічних матеріалів

2) застосування helper для CRUD. Причина - дивись 1

3) підключення bootstrap. Причина - дивись 1
