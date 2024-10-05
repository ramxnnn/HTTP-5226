# HTTP-5226
# Food Truck Tracker API

## Overview
The Local **Food Truck Tracker** System is a backend application built using ASP.NET Core, designed to help users discover food trucks, track their locations, browse menus, and manage their favorites. The system supports real-time updates and provides an efficient way for food truck lovers to explore food trucks in their area.

## Features
- **CRUD Operations** for Food Trucks, Locations, Menu Items, and Favorites.
- **User Authentication** using ASP.NET Identity.
- **Database Seeding** for initial data setup.
- **Swagger UI** for API documentation and testing endpoints.

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- Microsoft SQL Server (LocalDB)
- Swagger for API documentation
- Dependency Injection for service management

## Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (or any compatible IDE)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/FoodTruckTracker.git
   cd FoodTruckTracker

2. **Restore NuGet packages**
   ```bash
   dotnet restore

3. **Set up the database**
   Update the connection string in appsettings.json if necessary.
   Run the following commands to create and apply migrations

   ```bash
   add-migrations 
   update-database

4. **Running the Application**
   To start the application either use run button in the IDE or use the following command - 
   ```bash
   Use the run function with https or just use dotnet run
   
### Api Documentation
Swagger UI is integrated into the application for easy testing of API endpoints. Access it at https://localhost:7246/swagger.

### Endpoints

### Endpoints

1. **Food Trucks**
   - `GET /api/foodtrucks` - Get all food trucks.
   - `GET /api/foodtrucks/{id}` - Retrieve a specific food truck by ID.
   - `POST /api/foodtrucks` - Create a new food truck.
   - `PUT /api/foodtrucks/{id}` - Update a food truck.
   - `DELETE /api/foodtrucks/{id}` - Delete a food truck.

2. **Locations**
   - `GET /api/locations` - Get all locations.
   - `GET /api/locations/{id}` - Retrieve a specific location by ID.
   - `POST /api/locations` - Create a new location.
   - `PUT /api/locations/{id}` - Update a location.
   - `DELETE /api/locations/{id}` - Delete a location.

3. **Menu Items**
   - `GET /api/menuitems` - Get all menu items.
   - `GET /api/menuitems/{id}` - Retrieve a specific menu item by ID.
   - `POST /api/menuitems` - Create a new menu item.
   - `PUT /api/menuitems/{id}` - Update a menu item.
   - `DELETE /api/menuitems/{id}` - Delete a menu item.

4. **Favorites**
   - `GET /api/favorites` - Get all favorites.
   - `GET /api/favorites/{userId}/{foodTruckId}` - Retrieve a specific favorite for a user.
   - `POST /api/favorites` - Add a favorite.
   - `DELETE /api/favorites/{userId}/{foodTruckId}` - Remove a favorite.

## Planned Features
- Food Truck Ratings & Reviews: Allow users to rate and review food trucks.
- Real-Time Food Truck Location Updates: Integration with a maps API to provide real-time updates for food trucks’ locations.
- Promotions & Events: Food trucks can offer special deals and promote events in real time.
- Photo Uploads for Dishes: Users can upload photos of food truck dishes.



### Contributing
Contributions are welcome! Please feel free to submit a Pull Request or create an issue if you find any bugs or have suggestions for improvements.

### License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgements
Special thanks to the ASP.NET Core community for their invaluable resources and support.



