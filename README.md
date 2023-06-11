# MoviesWebMVCProject
This is an MVC project made using ASP.NET Core MVC as the project template, Entity Framework Core as the ORM and MS Sql as the database. 
In this project, there are two main subdivisions of the application which are the admin area and the customer area. 
In the admin area, the admin is allowed to create a various list of movie genre, then using the genreId which is the primary key of the database table storing the list of genre, it will act as a foreign key to another database table which will store a list of movies. The admin can also create a list of movies and match it to any of the available genres in the database. While creating a new entry for either a genre or a movie itself, there are validations that will be performed on the new entry to be created in order to ensure proper and correct details are stored in the database.

In the customer area, this side is reserved only for people visiting the website. On the home page, they will a display of all the various list of movies currently available and by clicking on the details button of each movie, they will be redirected to another page which will display the full details of the particular movie they clicked. In the customer area of the application, users are not able to edit or delete movies but they are only allowed to view the details of movies.



