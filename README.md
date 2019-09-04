# MoviesWebApp

## Commands

### Installed on API Project:
```
Install-Package Swashbuckle.AspNetCore
```

### Installed on Angular Project:
```
npm install ngx-pagination --save
```


### To execute API Project:
```
dotnet watch run
```

### To execute Angular Project:
```
ng serve
```


### Api Documentation:
- Access to see on UI: https://localhost:44305/swagger/
- Access to see json: https://localhost:44305/swagger/v1/swagger.json


### Architecture:
- Used three layers (similar to DDD), which are:
	- API layer - where it has the controller and helpers;
	- Domain layer - where it has the interfaces;
	- Infrastructur layer - where is the access to external API;