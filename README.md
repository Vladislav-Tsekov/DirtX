# DirtX

🏍️ **Welcome to DirtX**, a place for all things motocross! We offer a wide range of top-quality motocross gear, parts, oils, and accessories to fuel your passion for off-road adventures.

🔧 **Gear & Parts**: Explore our extensive collection of motocross gear and parts, handpicked from leading brands.

🛢️ **Oils & Lubricants**: Keep your ride running smoothly with our premium selection of oils and lubricants, formulated to withstand the rigors of off-road riding.

🏍️ **Used Motorcycles**: Looking for your next ride? Browse our curated selection of pre-owned motorcycles.

💡 **Expert Advice**: Need assistance or recommendations? Our team of motocross enthusiasts is here to help! Get expert advice on gear selection, maintenance tips, and more.

# Important information regarding the project
- Update the default database using the command:
> update-database -context ApplicationDbContext
- Update the scraper database using the command:
> update-database -context ScraperDbContext

This will automatically seed the dummy data and you will be able to run the program.
If you want to run the tests, first you must navigate to the "SeedUsedMotorcycles" method and comment the code inside, since the **Directory** and **Path** methods will interfere with NUnit framework. Unless you do that, all test will fail.

When playing around within the Admin Dashboard, do not delete default users. Those are:

Admin: 
> Name: admin@dirtx.com / Pass: AdminUser111
User:
> User: user@dirtx.com / Pass: NormalUser333 

The DirtX.Web profile is for development. If you want to experience the program as a regular user would, you must choose "IIS Express" as a startup project.
