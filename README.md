# dockertraining_compose

C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina>docker pull mysql
Using default tag: latest
latest: Pulling from library/mysql
c499e6d256d6: Pull complete                                                                                             22c4cdf4ea75: Pull complete                                                                                             6ff5091a5a30: Pull complete                                                                                             2fd3d1af9403: Pull complete                                                                                             0d9d26127d1d: Pull complete                                                                                             54a67d4e7579: Pull complete                                                                                             fe989230d866: Pull complete                                                                                             3a808704d40c: Pull complete                                                                                             826517d07519: Pull complete                                                                                             69cd125db928: Pull complete                                                                                             b5c43b8c2879: Pull complete                                                                                             1811572b5ea5: Pull complete                                                                                             Digest: sha256:b69d0b62d02ee1eba8c7aeb32eba1bb678b6cfa4ccfb211a5d7931c7755dc4a8
Status: Downloaded newer image for mysql:latest
docker.io/library/mysql:latest

C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina>docker images
REPOSITORY                             TAG                 IMAGE ID            CREATED             SIZE
dockertrainingcomposealfredomedina     dev                 08480dfad69f        18 minutes ago      207MB
mcr.microsoft.com/dotnet/core/aspnet   3.1-buster-slim     c819eb4381e7        13 days ago         207MB
mysql                                  latest              9228ee8bac7a        13 days ago         547MB

C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina>docker volume create dockertraining_compose
dockertraining_compose

C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina>docker run --name database_container -e MYSQL_RANDOM_ROOT_PASSWORD=yes -e MYSQL_DATABASE=fooddb -e MYSQL_USER=test -e MYSQL_PASSWORD=123456 -v dockertraining_compose:/var/lib/mysql -p 3018:3306 -d mysql
f4696cb19d4886a0062b804c8be9d94baf6b35dd325923dda5866258f7c888c6

C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina>docker build -f "C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina\dockertraining_compose_alfredo_medina\Dockerfile" --force-rm -t dockertraining_compose_img "C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina"
Sending build context to Docker daemon  31.74kB
Step 1/16 : FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
 ---> c819eb4381e7
Step 2/16 : WORKDIR /app
 ---> Using cache
 ---> 31233f91762d
Step 3/16 : EXPOSE 80
 ---> Using cache
 ---> 1b7275148c5f
Step 4/16 : FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
 ---> 597ba2726813
Step 5/16 : WORKDIR /src
 ---> Using cache
 ---> dd58c44d6027
Step 6/16 : COPY ["dockertraining_compose_alfredo_medina/dockertraining_compose_alfredo_medina.csproj", "dockertraining_compose_alfredo_medina/"]
 ---> Using cache
 ---> 8bb2c0da5ff6
Step 7/16 : RUN dotnet restore "dockertraining_compose_alfredo_medina/dockertraining_compose_alfredo_medina.csproj"
 ---> Using cache
 ---> b09a76e33725
Step 8/16 : COPY . .
 ---> 70b8fe516ce8
Step 9/16 : WORKDIR "/src/dockertraining_compose_alfredo_medina"
 ---> Running in e33dfa817169
Removing intermediate container e33dfa817169
 ---> 97675ed970ab
Step 10/16 : RUN dotnet build "dockertraining_compose_alfredo_medina.csproj" -c Release -o /app/build
 ---> Running in e0a5a149c602
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 67.48 ms for /src/dockertraining_compose_alfredo_medina/dockertraining_compose_alfredo_medina.csproj.
  dockertraining_compose_alfredo_medina -> /app/build/dockertraining_compose_alfredo_medina.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:06.87
Removing intermediate container e0a5a149c602
 ---> 6d5c15fdb22b
Step 11/16 : FROM build AS publish
 ---> 6d5c15fdb22b
Step 12/16 : RUN dotnet publish "dockertraining_compose_alfredo_medina.csproj" -c Release -o /app/publish
 ---> Running in 303b9f299cb8
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 67.43 ms for /src/dockertraining_compose_alfredo_medina/dockertraining_compose_alfredo_medina.csproj.
  dockertraining_compose_alfredo_medina -> /src/dockertraining_compose_alfredo_medina/bin/Release/netcoreapp3.1/dockertraining_compose_alfredo_medina.dll
  dockertraining_compose_alfredo_medina -> /app/publish/
Removing intermediate container 303b9f299cb8
 ---> 4ed7f4b9693e
Step 13/16 : FROM base AS final
 ---> 1b7275148c5f
Step 14/16 : WORKDIR /app
 ---> Using cache
 ---> a07fd04228ce
Step 15/16 : COPY --from=publish /app/publish .
 ---> 8412346b7669
Step 16/16 : ENTRYPOINT ["dotnet", "dockertraining_compose_alfredo_medina.dll"]
 ---> Running in 5c0d5ca6b458
Removing intermediate container 5c0d5ca6b458
 ---> ea3b07e77e23
Successfully built ea3b07e77e23
Successfully tagged dockertraining_compose_img:latest
SECURITY WARNING: You are building a Docker image from Windows against a non-Windows Docker host. All files and directories added to build context will have '-rwxr-xr-x' permissions. It is recommended to double check and reset permissions for sensitive files and directories.

C:\Users\Alfredo\source\repos\dockertraining_compose_alfredo_medina>docker run --name api_container -p 8091:80 -e "ConnectionStrings:FoodDB"="Server=database_container;Port=3306;Database=fooddb; Uid=test; Pwd=123456" --link database_container -it dockertraining_compose_img
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
