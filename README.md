# Cafe Management System
> Designed by:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Luke Mcwha and Cory Mifsud<br/>Implemented by:&nbsp;&nbsp;&nbsp;Luke Mcwha


## Introduction

This project was built to complete as a University Assignment. The goal is to create a solution to make a Cafe more scalable.

The new system will support a number of features: Table reservations, taking customer orders, informing the kitchen about the orders, informing staff about customers who have waited a long time for their order, customer receipts, handling payments. There will also be an online ordering solution incorporated for takeaway meals. These aspects combined complete the goal of scaling the cafe’s processes to accommodate more customers.

This project has accompanying documentation that describes the structure of the system.

## Documentation

This project is designed using the Model View ViewModel (MVVM). Therefore much of the documentation is split into its separate components; View, Model and ViewModel. To simplify the project, we assume that the Database model will mimic the service layer data. No model was made for this project.

### View

#### Command Processor
This project uses a commandline interface to interact with the user. This command processor singleton object let's that will search a dictionary for a command object to process the task. The first word an input command is the identifier for the command.

<p align="center">
  <img src="https://github.com/LukeMcwha/CafeManagementSystem/blob/master/readme-images/commandProcessorUml.png?raw=true" width="500" />
</p>
> Programs Commandline Processor structure

#### Command Objects
The below commands represent the different instances that exist within a command processor. These commands can be added and removed from the command processor dynamically. This occurs when changing states. eg from Kitchen to Customer state.

<p align="center">
  <img src="https://github.com/LukeMcwha/CafeManagementSystem/blob/master/readme-images/commandChildren1.png?raw=true" width="700" />
</p>
<p align="center">
  <img src="https://github.com/LukeMcwha/CafeManagementSystem/blob/master/readme-images/commandChildren2.png?raw=true" width="700" />
</p>
<p align="center">
  <img src="https://github.com/LukeMcwha/CafeManagementSystem/blob/master/readme-images/commandChildren3.png?raw=true" width="700" />
</p>
> Command Processor Command objects.

#### Entity State Management
There are three entities that can act upon this system: Customer, Kitchen and Front of House. These entities are able to access different commands based on their role and therefore can make different interactions with the system.

<p align="center">
  <img src="https://github.com/LukeMcwha/CafeManagementSystem/blob/master/readme-images/statePattern.png?raw=true" width="700" />
</p>
> Entity State Management.

### View Model
There are 3 main patterns used to develop the ViewModel: Singleton, Composition, Event Dispatch patterns. Each of these patterns play a different part completing all functions required. The Singleton patterns hold the state and data. This is important when keeping the consistant data across many States. Composition pattern is utilised to allow for polymophic code structures when objects contain objects of the same type. The event dispatcher is the way information is passed from object to object when an event occurs. The main event in this project is a timed event. This notifies all subscribed objects of the event occuring. 

<p align="center">
  <img src="https://github.com/LukeMcwha/CafeManagementSystem/blob/master/readme-images/viewModelDesign.png?raw=true" width="700">
</p>
