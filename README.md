Simple C# Console Task Manager

📝 Overview

The Simple C# Console Task Manager is a command-line interface (CLI) application built with C# that allows users to manage a list of to-do items. It features a modular, object-oriented design using interfaces, a factory pattern for task creation, and a simple in-memory storage system.

This application demonstrates clean separation of concerns, making it easy to extend with different task types or persistent storage mechanisms (like database integration) in the future.

✨ Features

View Tasks: Display all tasks with their unique ID, name, and completion status.

Add Tasks: Easily add new tasks from the console.

Complete Tasks: Toggle the completion status of any task by its ID.

Update Tasks: Modify the description of an existing task.

Delete Tasks: Remove tasks from the list by their ID.

Modular Design: Utilizes the Dependency Injection pattern (via constructor injection) with a TaskFactory and ITaskStorage for flexible component swapping.

🛠️ Usage

This is a command-line application. When you run the application, it will display the current list of tasks and prompt you for a command.

Available Commands

Commands are entered in the format: [command] [parameters...]

Command

Example

Description

add

add Buy groceries

Creates a new task with the description "Buy groceries".

complete

complete 3

Toggles the completion status of the task with ID 3.

update

update 1 Finish README

Changes the description of task ID 1 to "Finish README".

delete

delete 5

Removes the task with ID 5 from the list.

exit

exit

Closes the application.

🏗️ Project Structure

The codebase is organized using several classes and interfaces to implement key design patterns:

File

Role & Pattern

Description

Program.cs

Entry Point

Initializes the core components, sets up the MainTaskManager, and runs the command-line loop.

Task.cs

Interface/Model

Defines the ITask interface and the concrete StandardTask class, encapsulating task data and behavior (completion, update).

TaskStorage.cs

Storage/Repository

Defines ITaskStorage and implements MemoryTaskStorage, which handles all CRUD operations on tasks using an in-memory Dictionary<int, ITask>.

TaskFactory.cs

Factory Pattern

Provides the TaskFactory class responsible for creating new ITask objects, abstracting instantiation logic.

TaskManager.cs

Manager/Facade

Defines the MainTaskManager which coordinates calls between the TaskFactory and the ITaskStorage, acting as the main business logic layer.

TaskTest.cs & TaskManagerTest.cs

Unit Tests

Contains test methods to verify the functionality of task objects and the overall task management logic.
