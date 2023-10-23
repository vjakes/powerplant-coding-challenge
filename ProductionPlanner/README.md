# powerplant-coding-challenge implementation


## Welcome !

This is a quick implementation of powerplant production planning service. Functionality such as docker containerization and CO2 factoring in was omitted from this implementation.

## Running/testing

### In Visual Studio (or IDE of your choice)

* Open the `ProductionPlanner.sln`
* Run the only project

This will open up browser with a swagger page with UI to send request. You can also send your requests via a tool such as postman to [url](http://localhost:8888/ProductionPlan) stated in the assignment.

### Next steps

As this is a wonderfully incomplete solution of the assignment, this is just a quick brainstorm of what to do next in no particular order:

* Configure and utilize the serilog logger to provide meaningful outputs
* Provide means to store the requests history. Initially it seemed like a good idea to store the requests in relational DB, but it may actually be good to just store the raw requests as a long string in some key-value storage for future reference/auditing
* Provide capacity builders that will also factor in the price of CO2 emissions 
* Support more power sources - solar, hydro, pump, nuclear, ...
* Store plans sent out in DB and attempt to adjust existing (last) plan to minimize the "startup/cutoff" issues especially with big and slow-reacting sources (it takes time to bring gas fired plant from 100 to 350MW...)
* Error handling filter into the pipeline (although we do catch all exceptions in the controller)
* ...

