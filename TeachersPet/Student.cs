using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersPet
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string ParentEmail {  get; set; }
        public string BackupEmail { get; set; }
        public string ParentPhoneNumber { get; set; }

        public Student(string firstName, string lastName, string parentFirstName, string parentLastName, string parentEmail, string backupEmail, string parentPhoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ParentFirstName = parentFirstName;
            this.ParentLastName = parentLastName;
            this.ParentEmail = parentEmail;
            this.BackupEmail = backupEmail;
            this.ParentPhoneNumber = parentPhoneNumber;
        }

    }
}