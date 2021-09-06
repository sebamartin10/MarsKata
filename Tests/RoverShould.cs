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
        [Test]
        public void Be_At_The_Position_0X_0Y_At_The_Beggining() {
            //Given
            Rover rover = new Rover();
            //Then
            Assert.AreEqual(0,rover.PositionX);
            Assert.AreEqual(0, rover.PositionY);
        }
        [Test]
        public void Be_Facing_North_At_The_Beggining() {
            //Given
            Rover rover = new Rover();
            
            //Then
            Assert.AreEqual('n', rover.CardinalOrientation);
        }
        [Test]
        public void Be_At_The_Position_0X_1Y_When_Command_Is_Forward_And_Previous_Position_Was_0x_0Y() {
            //Given;
            Rover rover = new Rover();
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
            Rover rover = new Rover();
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
        public void Be_Facing_North_If_Last_Command_Was_Forward() {
            //Given
            Rover rover = new Rover();
            char[] commands = new char[]{'b','f','b','f','r','b','l','f' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual('n', rover.CardinalOrientation);
        }
        [Test]
        public void Be_Facing_South_If_Last_Command_Was_Backward()
        {
            //Given
            Rover rover = new Rover();
            char[] commands = new char[] { 'b', 'f', 'b', 'f', 'r', 'b', 'l', 'f','b' };
            //When
            rover.Move(commands);
            //Then
            Assert.AreEqual('s', rover.CardinalOrientation);
        }

    }

    
}
