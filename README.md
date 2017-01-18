2# ForChepa
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
   {
        public int Id { get; set; }
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
 
 ```csharp int PageSize = 10; ``` - кількість елементів для відображення на одній сторінці
```csharp return View(th.OrderBy(t=>t.Id).ToPagedList(PageNumber,PageSize));``` - OrderBy повинно передувати Skip та Take,що застосовує ToPagedList


