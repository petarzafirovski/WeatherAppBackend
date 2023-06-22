<h1>WeatherApp backend</h1>
<div>
  <p>The only requirement is to download docker locally. No need to install MySQL workbench or any other database management studio. Same goes for the backend part, this goes for a reason if you do not have installed locally Visual Studio with the necessary SDK's.</p>
</div>

After that, just run: `docker-compose up -d` in the command line in the same root where the `Dockerfile` and `docker-compose.yml` files are stored.

To access swagger ui, navigate to the following URL after starting both of the containers: http://localhost:80/swagger/index.html.

No need to apply migrations manually, they are applied once the container for the backend is started. 

