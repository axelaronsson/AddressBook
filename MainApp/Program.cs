using Business.Models;
using Business.Services;
using MainApp.MenuDialog;

var fileService = new FileService();
var contactService = new ContactService(fileService);
var menu = new MenuDialog(contactService);

menu.ShowMenu();