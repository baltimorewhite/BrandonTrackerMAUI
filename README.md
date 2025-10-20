# BrandonTrackerMAUI

A mobile app built with .NET MAUI and C# to help drivers at Brandon Shredding track their daily tasks, view completed jobs, and personalize their experience. This project is adapted from a real-world logistics tool and fulfills the requirements of the ICT40120 Mobile Development assessment.

## 📱 Purpose

BrandonTrackerMAUI replaces paper-based run sheets with a mobile-friendly interface that connects to a Google Sheets API. It allows drivers to:

- View daily tasks assigned from the Run Sheet
- Mark tasks as completed
- Review completed tasks in a separate view
- Edit task details if mistakes are made
- Customize preferences like theme and font size

## 🧩 Technologies Used

- **.NET MAUI** for cross-platform mobile development
- **C#** for backend logic and data models
- **XAML** for UI layout and styling
- **Google Sheets API** for external data retrieval
- **MVVM pattern** for clean architecture
- **Preferences API** for user settings

## 🧭 App Structure

| Page            | Description                                                                 |
|-----------------|-----------------------------------------------------------------------------|
| HomePage        | Welcome screen with navigation to other sections                            |
| TaskListPage    | Displays today's tasks with details and completion buttons                  |
| TaskDetailPage  | Shows full task info and allows marking as completed or editing             |
| SettingsPage    | Allows users to toggle dark mode and adjust font size                       |

## ✅ Key Features

- Dynamic task loading from Google Sheets
- Completion tracking with visual separation
- Editable entries with validation
- Responsive layout for mobile devices
- User preferences saved locally

## 📦 Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR-USERNAME/BrandonTrackerMAUI.git
