# selenium-grid-nunit-docker
This a simple example of how to run tests in parallel in a docker container using selenium grid.

Tech stack:

- .Net core 3.1
- nUnit
- WebDriverManager 2.11.x
- docker-compose
  - selenium/hub
  - selenium/node-firefox-debug
  - selenium/node-chrome-debug
  
 # Before run tests:
  1) Ensure you have docker for windows installed.
  2) Clone the repo and access it from powershell. Once you're in the same directory of the docker-compose.yml file, execute the command "docker-compose up" 
  to create the containers.

# Access the node container via VNC
  1) Download VNC and run it.
   - The ip 127.0.0.1:4578 can be used to access chrome node.
   - The ip 127.0.0.1:4577 can be used to access firefox node.
