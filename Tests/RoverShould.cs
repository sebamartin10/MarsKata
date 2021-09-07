using NUnit.Framework;
using RoverGeolocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    
    public class RoverShould
    {
        Rover rover;

        [SetUp]
        public void Before() {
            rover = new Rover();
        }

        [Test]
        public void Be_At_The_Position_0X_0Y_At_The_Beggining() {
            
            //Then
            Assert.AreEqual(0,rover.PositionX);
            Assert.AreEqual(0, rover.PositionY);
        }
        [Test]
        public void Be_Facing_North_At_The_Beggining() {
            //Then
            Assert.AreEqual('n', rover.CardinalOrientation);
        }
        [Test]
        public void Be_At_The_Position_0X_1Y_When_Command_Is_Forward_And_Previous_Position_Was_0x_0Y() {
            //Given;
            char[] command = new char[1];
            command[0] = 'f';
            //When
            rover.Move(command);
            //Then
            Assert.AreEqual(1, rover.PositionY);
            Assert.AreEqual(0, rover.PositionX);
        }
        [Test]
        public void Be_At_The_Position_2X_2Y_When_Command_Is_Backward_And_Previous_Position_Was_2X_3Y() {
            //Given
            rover.PositionX = 2;
            rover.PositionY = 3;
            char[] commands = new char[1];
            commands[0] = 'b';
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual(2, rover.PositionY);
            Assert.AreEqual(2, rover.PositionX);
        }
        [Test]
        public void Be_At_The_Position_Negative3X_3Y_When_Command_Is_Left_And_Previous_Position_Was_Negative2X_3Y() {
            //Given
            
            rover.PositionX = -2;
            rover.PositionY = 3;
            char[] commands = new char[1];
            commands[0] = 'l';
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual(3, rover.PositionY);
            Assert.AreEqual(-3, rover.PositionX);
        }
        [Test]
        public void Be_At_The_Position_10X_1Y_When_Command_Is_Right_And_Previous_Position_Was_9x_1Y() {
            //Given
            
            rover.PositionX = 9;
            rover.PositionY = 1;
            char[] commands = new char[1] { 'r' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual(1, rover.PositionY);
            Assert.AreEqual(10, rover.PositionX);
        }
        [Test]
        public void Be_Facing_North_If_Last_Command_Received_Was_Forward() {
            //Given
         
            char[] commands = new char[]{'b','f','b','f','r','b','l','f' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual('n', rover.CardinalOrientation);
        }
        [Test]
        public void Be_Facing_South_If_Last_Command_Received_Was_Backward()
        {
            //Given
          
            char[] commands = new char[] { 'b', 'f', 'b', 'f', 'r', 'b', 'l', 'f','b' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual('s', rover.CardinalOrientation);
        }
        [Test]
        public void Be_Facing_East_If_Last_Command_Received_Was_Left() {
            //Given
            char[] commands = new char[] { 'b', 'f', 'r', 'f', 'r', 'b', 'l', 'r', 'l' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual('e', rover.CardinalOrientation);
        }
        [Test]
        public void Be_Facing_West_If_Last_Command_Received_Was_Right() {
            //Given
            char[] commands = new char[] { 'f', 'f', 'f', 'f', 'r', 'b', 'l', 'b', 'r' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual('w', rover.CardinalOrientation);
        }
        [Test]
        public void Have_Accepted_Commands() {

            //Then
            Assert.IsNotEmpty(rover.AcceptedCommands);
        }
        [TestCase(new char[] { 'f','b','x'},false)]
        [TestCase(new char[] { 'f', 'b', 'x','r' }, false)]
        [TestCase(new char[] { 'f', 'b', 'x','l' }, false)]
        [TestCase(new char[] { 'f', 'b', 'x','y' }, false)]
        [TestCase(new char[] { 'f'}, true)]
        [TestCase(new char[] { 'f', 'b' }, true)]
        [TestCase(new char[] { 'f', 'b','l' }, true)]
        [TestCase(new char[] { 'f', 'b', 'l','r' }, true)]
        public void Check_Commands_Integrity(char[] commands, bool expected) {
            //When
            bool actual = rover.CheckCommandsIntegrity(commands);
            
            //Then
            Assert.AreEqual(expected, actual);
        }

    }

    
}
