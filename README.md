El funcionamiento de la aplicación consiste en gestionar la información de diferentes tablas relacionadas entre sí. Tenemos tres tablas: usuarios, compañías y reservas.
Primero tenemos un menú público para todos los usuarios, donde puedes registrate o iniciar sesión. Para ambas funcionalidades tendremos que elegir si somos un usuario o una compañía.
Una vez dentro podemos realizar distintas funciones, como buscar una compañía por su nombre o borrar y modificar un usuario. 
Por último, una compañía puede registrar un viaje y se guarda en una lista de viajes asociada a cada una de las compañías.

La aplicación se encuentra contenerizada en Docker Hub, el comando para bajarla es: docker pull mariozgz/practices:1.0

A la hora de crear el contenedor, tenemos una variable de entorno a la cual le ponemos el puerto que estamos usando, además creamos un volumen llamado Data en el cual guardamos los ficheros json. El comando es:
docker run -it -e PORT=4746 -p 4746:4746 -v ${PWD}/Presentation/users.json:/Practices/Data/users.json -v ${PWD}/Presentation/companies.json:/Practices/Data/companies.json mariozgz/practices:1.0
