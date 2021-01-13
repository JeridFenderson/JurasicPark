# JurasicPark PEDAC

## Problem

### Create a class to represent your dinosaurs

#### The class should have the following properties

- Name
- DietType - This will be "carnivore" or "herbivore"
- WhenAcquired - This will default to the current time when the dinosaur is created
- Weight - How heavy the dinosaur is in pounds.
- EnclosureNumber - the number of the pen the dinosaur is in
- Add a method Description to your class to print out a description of the dinosaur to include all the properties - Create an output format

### Keep track of your dinosaurs in a List<Dinosaur>

When the console application runs, it should let the user choose one of the following actions:

#### View

This command will show the all the dinosaurs in the list, ordered by WhenAcquired. If there aren't any dinosaurs in the park then print out a message that there aren't any.

#### Add

This command will let the user type in the information for a dinosaur and add it to the list. Prompt for the Name, Diet Type, Weight and Enclosure Number, but the WhenAcquired must be supplied by the code.

#### Remove

This command will prompt the user for a dinosaur name then find and delete the dinosaur with that name.

#### Transfer

This command will prompt the user for a dinosaur name and a new EnclosureNumber and update that dino's information.

#### Summary

This command will display the number of carnivores and the number of herbivores.

#### Quit

This will stop the program

### Adventure Mode

Consider what to do in Add/Remove/Transfer if multiple dinosaurs have the same name

- Have Transfer and Remove show the multiple dinosaurs and prompt the user which one to work with

Add an option to view the Dinosaurs acquired after a given date (to be given by the user)

Add an option to view all the Dinosaurs in a given enclosure number

### Epic Mode

Learn how to read and write from a file

At the start of the program load all the dinosaurs from a file

When the program ends write out all the dinosaurs to the same file

---

## Examples

Add a T-Rex, Carnivore, Date-Time, 20,000 lbs, Enclosure 1 and be able to call this info to display on console

Add multiple dinosaurs and put them on the list

View entire list, right now list just will display T-Rex

Delete T-Rex

Move T-Rex from Enclosure 1 to Enclosure 3

Say how many carnivores and herbivores there are on the console, right now is just 1 carnivore (T-Rex)

---

## Data

- Name
- DietType
- WhenAcquired
- Weight
- Enclosure Number

- list of the above data

---

## Algorithm

Say Hello

Create a class for each individual Dinosaur that contains each requested property

Create a menu that uses a while loop to keep the program running until the user says QUIT

Within the while loop menu, give the user the option to view, add, remove, transfer, view summary, and exit program

Create a method for view

- display the dinosaur list in a user friendly format in order acquired
- ### Adventure Mode
- create a method for viewing dinosaurs acquired after a certain date
- create a method for viewing dinosaurs in a given enclosure number

Create a method for add

- capture all user required inputs for the dinosaur class, and place that new object within the dinosaur list

Create a method for remove

- ask the user for the dinosaur's name
- find the dinosaur and display dinosaurs info
- have user confirm that the dinosaur info displayed is the dinosaur they are looking for and they want to remove it
- ### Adventure Mode
- if dinosaur is not what user wants and another exists, repeat all steps above except for asking the dinosaur's name with next dinosaur
- remove selected dinosaur from list

Create a method for transfer

- ask the user for the dinosaur's name
- find the dinosaur and display dinosaurs info
- have user confirm that the dinosaur info displayed is the dinosaur they are looking for and they want to transfer it
- ### Adventure Mode
- if dinosaur is not what user wants and another exists, repeat all steps above except for asking the dinosaur's name with next dinosaur
- ask the user where they'd like to transfer the dinosaur
- transfer the selected dinosaur

Create a method for summary

- display the number of carnivores and the number of herbivores within the list of dinosaurs

Say Goodbye
