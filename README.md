🚗 CarSimulator
A modular, console-based car driving simulation built in C#. This project simulates vehicle behavior, driver state (like tiredness and hunger), and integrates both unit and API-based interaction testing. The structure is layered for better testability and separation of concerns.

📌 Description
CarSimulator is a C#-based simulation program that allows users to interactively drive a virtual car while testing its internal systems. The program includes:

A command-line interface for car control (move, turn, reverse, refuel, rest)

Driver condition monitoring (tiredness and hunger simulation)

Integration with the RandomUser API to simulate dynamic drivers

Support for unit testing using MSTest and NUnit

Clear separation of logic into Core, Services, and Testing Projects


🧩 Project Structure
CarSimulator – Main application logic (car, driver, status, actions)

Services – API and service classes (e.g. GetTheApi.cs, ApiResponse.cs)

CarSimulator.Tests – Unit & integration tests with MSTest

CarSimulator.NUnit – Additional unit tests using NUnit

✅ Features
✅ Simulated driver states: Tiredness & Hunger

✅ Turn-based driving control (forward, turn left/right, reverse)

✅ Dynamic driver generation via public API

✅ Parallel test execution with MSTest/NUnit

✅ Mocking with Moq for interface-based testing

✅ Console-based user interaction

🛠 Technologies Used
C# .NET 9.0

MSTest / NUnit / Moq

Console UI

HttpClient + JSON (Newtonsoft.Json)

🔧 Installation
bash
Kopiera
Redigera

git clone https://github.com/Nasi-Malek/CarSimulator.git
Open the solution in Visual Studio 2022 (v17.14+)

Restore NuGet packages.

Build the solution (Ctrl+Shift+B)

🧪 Testing Instructions
Unit Testing:

MSTest-based tests: in CarSimulator.Tests

NUnit-based tests: in CarSimulator.NUnit

Run via Test Explorer in Visual Studio or:

bash
Kopiera
Redigera
dotnet test CarSimulator.Tests
dotnet test CarSimulator.NUnit
Test Types:

✅ Core behavior tests (fuel, direction, tiredness)

✅ Edge case tests (e.g. hunger thresholds)

✅ Integration test for external API (ApiTest.cs)


🚀 Usage
Run the CarSimulator project.

The program fetches a random driver from the API.

Navigate using options:

Move forward

Turn (left/right)

Reverse

Refuel

Rest

Driver and car status will be shown at each turn.
