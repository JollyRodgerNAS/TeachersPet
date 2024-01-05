using System;
using System.Collections;
using TeachersPet;
using MongoDB.Driver;
using MongoDB.Bson;

string connectionString = "mongodb+srv://nickstewart13:X3PbNKiLE8Bi8nR2@teacherspet.ttfrwva.mongodb.net/?retryWrites=true&w=majority";
string databaseName = "StudentDatabase";
string collectionName = "Students";


string anotherOperation;

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<Student>(collectionName);
bool isMongoLive = db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(10000);

if (isMongoLive)
{
    Console.WriteLine("Do you want to create a student[0], read a student[1], update a student[2], see all students[3] or delete a student[4]?");
    Console.WriteLine("Input the corresponding number to the operation you would like to perform: ");
    string response = Console.ReadLine();
    bool proceed = true;
    int count;
    while (proceed == true)
    {

        if (response == "0")
        {
            Console.WriteLine("How many students would you like to add?");
            count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                CreateStudent();
                Console.WriteLine("Congratulations! You created a student!");
            }
            Console.WriteLine("Would you like to perform another operation? Y/N");
            anotherOperation = Console.ReadLine().ToUpper();
            if (anotherOperation == "Y")
            {
                proceed = true;
                Console.WriteLine("Do you want to create a student[0], read a student[1], update a student[2], see all students[3] or delete a student[4]?");
                Console.WriteLine("Input the corresponding number to the operation you would like to perform.");
                response = Console.ReadLine().ToUpper();
            }
            else
            {
                proceed = false;
            }
        }
        else if (response == "1")
        {
            ReadStudent();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Would you like to perform another operation? Y/N");
            anotherOperation = Console.ReadLine().ToUpper();
            if (anotherOperation == "Y")
            {
                proceed = true;
                Console.WriteLine("Do you want to create a student[0], read a student[1], update a student[2], see all students[3] or delete a student[4]?");
                Console.WriteLine("Input the corresponding number to the operation you would like to perform.");
                response = Console.ReadLine().ToUpper();
            }
            else
            {
                proceed = false;
            }
        }
        else if (response == "2")
        {
            UpdateStudent();
            Console.WriteLine("Congratulations! You updated a student!");
            Console.WriteLine("Would you like to perform another operation? Y/N");
            anotherOperation = Console.ReadLine().ToUpper();
            if (anotherOperation == "Y")
            {
                proceed = true;
                Console.WriteLine("Do you want to create a student[0], read a student[1], update a student[2], see all students[3] or delete a student[4]?");
                Console.WriteLine("Input the corresponding number to the operation you would like to perform.");
                response = Console.ReadLine().ToUpper();
            }
            else
            {
                proceed = false;
            }
        }
        else if (response == "3")
        {
            ReadAllStudents();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Would you like to perform another operation? Y/N");
            anotherOperation = Console.ReadLine().ToUpper();
            if (anotherOperation == "Y")
            {
                proceed = true;
                Console.WriteLine("Do you want to create a student[0], read a student[1], update a student[2], see all students[3] or delete a student[4]?");
                Console.WriteLine("Input the corresponding number to the operation you would like to perform.");
                response = Console.ReadLine().ToUpper();
            }
            else
            {
                proceed = false;
            }
        }
        else if (response == "4")
        {
            DeleteStudent();
            Console.WriteLine("The student has been deleted!");
            Console.WriteLine("Would you like to perform another operation? Y/N");
            anotherOperation = Console.ReadLine().ToUpper();
            if (anotherOperation == "Y")
            {
                proceed = true;
                Console.WriteLine("Do you want to create a student[0], read a student[1], update a student[2], see all students[3] or delete a student[4]?");
                Console.WriteLine("Input the corresponding number to the operation you would like to perform.");
                response = Console.ReadLine().ToUpper();
            }
            else
            {
                proceed = false;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice!");
            proceed = false;
        }
    }
}
else
{
    Console.WriteLine("Connection failed!");
}

async void CreateStudent()
{
    Console.WriteLine("Enter student first Name");
    string studentFirstName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter student last name");
    string studentLastName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent first name");
    string parentFirst = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent last name");
    string parentLast = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent email");
    string email = Console.ReadLine();
    Console.WriteLine("Enter parent backup email");
    string emailBackup = Console.ReadLine();
    Console.WriteLine("Enter parent phone number");
    string parentNumber = Console.ReadLine();

    Student stud = new Student (studentFirstName, studentLastName, parentFirst, parentLast, email, emailBackup, parentNumber);

    await collection.InsertOneAsync(stud);
}
async void ReadStudent()
{
    Console.WriteLine("Enter student first Name");
    string studentFirstName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter student last name");
    string studentLastName = Console.ReadLine().ToUpper();
    var againUserRequest = await collection.FindAsync(studentLastName => true);
    var found = false;
 
    foreach (var user in againUserRequest.ToList())
    {
        if (user.LastName == studentLastName && user.FirstName == studentFirstName)
        {
            Console.WriteLine("This is the student you requested: ");
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.ParentPhoneNumber}");
            Console.WriteLine($"{user.ParentFirstName} {user.ParentLastName}");
            Console.WriteLine($"{user.ParentEmail} {user.BackupEmail}");
            found = true;
        }
    }
    if (found == false)
    {
        Console.WriteLine("No student by that name exists!");
    }


}
async void ReadAllStudents()
{
    Console.WriteLine("This is a list of all students:");
    var userRequest = await collection.FindAsync(_ => true);
    foreach (var user in userRequest.ToList())
    {
        Console.WriteLine($"{user.FirstName} {user.LastName}");
    }
}

//UpdateStudent still in progress
async void UpdateStudent()
{
    Console.WriteLine("Enter student first Name");
    string studentFirstName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter student last name");
    string studentLastName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter the updated information:");
    Console.WriteLine("Enter student first Name");
    string newStudentFirstName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter student last name");
    string newStudentLastName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent first name");
    string newParentFirst = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent last name");
    string newParentLast = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent email");
    string newEmail = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent backup email");
    string newEmailBackup = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter parent phone number");
    string newParentNumber = Console.ReadLine().ToUpper();
    var againUserRequest = await collection.FindAsync(studentLastName => true);

    Student stud = new Student(newStudentFirstName, newStudentLastName, newParentFirst, newParentLast, newEmail, newEmailBackup, newParentNumber);

    foreach (var user in againUserRequest.ToList())
    {
        if (user.LastName == studentLastName && user.FirstName == studentFirstName)
        {
            Console.WriteLine($"{studentFirstName} {studentLastName}====== {user.FirstName} {user.LastName}");
            await collection.DeleteOneAsync(studentLastName => true);
            await collection.InsertOneAsync(stud);

        }
        /*else
        {
            Console.WriteLine("update failed");
        }*/

    }


}

//DeleteStudent still in progress
async void DeleteStudent()
{
    Console.WriteLine("Enter student first Name");
    string studentFirstName = Console.ReadLine().ToUpper();
    Console.WriteLine("Enter student last name");
    string studentLastName = Console.ReadLine().ToUpper();
    var againUserRequest = await collection.FindAsync(studentLastName => true);
    
    foreach (var user in againUserRequest.ToList())
    {
        var filter = Builders<Student>.Filter.Regex(user.LastName, studentLastName);
        if (user.LastName == studentLastName && user.FirstName == studentFirstName)
        {
            await collection.DeleteOneAsync(filter);
        }
    }

}