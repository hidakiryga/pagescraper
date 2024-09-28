ways to zip deploy:

1. az.azcli have cmds that helps to zip deploy to azure funtion

2. POST req https://<fn app name>.scm.azurewebsites.net/api/zipdeploy
   add your zip in binaries
   authentication bearere token or basic auth
