# My_contact_mangement_app

This is a simple Angular application for managing contacts, featuring a contact list, a form for adding/editing contacts, and basic CRUD operations via a backend API. The application is designed for efficient management of personal or business contacts and utilizes Angular 18.x.

## Features

- View a list of contacts
- Add a new contact
- Edit existing contacts
- Delete contacts
- Navigation and routing for smooth UI transitions
- Contact data persisted with an external API

## Project Structure

The main parts of the project are organized as follows:

- **src/app/contact-list**: Component to display the list of contacts.
- **src/app/contact-form**: Component for adding or editing contacts.
- **src/app/services**: Contains the `ContactService` for interacting with the backend API.
- **src/app/models**: Contains data transfer objects for contacts and API responses.

## Prerequisites

Ensure you have the following installed:

- [Node.js](https://nodejs.org/) (v14 or later)
- [Angular CLI](https://angular.io/cli) (v18.2.1 or later)
- [Git](https://git-scm.com/)

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/contact-management-app.git
   cd contact-management-app
   ```

2. **Install dependencies:**
   ```bash
   npm install
   ```

3. **Set up backend API:**
   Update the backend API URL in `src/app/services/contact.service.ts` if different from the default (`https://localhost:7214/api/contacts`).

## Running the Application

### Development Server

To start the application in development mode:

```bash
npm start
```

Navigate to `http://localhost:4200/` in your browser. The app will automatically reload if you make code changes.

### Build

To build the project for production:

```bash
npm run build
```

The production files will be generated in the `dist/` directory.

### Testing

To run tests:

```bash
npm test
```

## Project Configuration

- **Angular Configuration**: Configured in `angular.json`
- **Application Routes**: Defined in `src/app/app.routes.ts`
- **Build and Serve Configurations**:
  - Default build and serve configurations are in `angular.json`.
  - You can use `ng serve --configuration production` to run the app in production mode.

## API Endpoints

The `ContactService` (`src/app/services/contact.service.ts`) interacts with the following endpoints:

- **GET /contacts**: Retrieve all contacts.
- **POST /contacts**: Create a new contact.
- **PUT /contacts/{id}**: Update an existing contact.
- **DELETE /contacts/{id}**: Delete a contact by ID.
- **GET /contacts/{id}**: Retrieve a contact by ID.

## Project Dependencies

- **Angular 18.x**: Core framework
- **RxJS 7.8**: Reactive programming library
- **Zone.js**: Angular's change detection mechanism

### Dev Dependencies

- **@angular-devkit/build-angular**: CLI and build tools
- **Karma and Jasmine**: Testing frameworks
- **Typescript 5.5.x**: Language support

## Contributing

1. Fork the repository.
2. Create your branch (`git checkout -b feature/my-feature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/my-feature`).
5. Open a Pull Request.

## License

This project is open-source under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Contact

For issues, suggestions, or contributions, please contact **Gurudatt Kayastha** at [itsmeguru70@gmail.com](mailto:itsmeguru70@gmail.com).
