import os
import sys

# docker build -t aspnetapp .
# docker run -d -p 8080:80 --name myapp aspnetapp

# Start UP API
print("Starting the API Now ...")
os.system("docker start myapp")

print("Running Test Now ...")
os.system("cd componenttest && dotnet test")