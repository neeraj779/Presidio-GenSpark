## Lernings
- EF Core
- Database First Approach - Scaffold-DbContext Command
- Code First Approach - Fluent API
- Scaffold-DbContext Command


### Connection Strings
```bash
Data Source=9SXBBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTracker;`
Data Source=9SXBBX3\\SQLEXPRESS;Initial Catalog=dbEmployeeTracker;user id=sa;password=abcd123`
```

### Scaffold-DbContext Command
```bash
Scaffold-DbContext "Data Source=9SXBBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTracker" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
```

### Tasks
Take your app built on Day-7 Question. Convert the repository layer to EF Core. 
There should be no changes in BL and FE. Use Database First approch
