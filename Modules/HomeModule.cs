using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace ContactList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["index.cshtml"];
      };
      Get["/view_contacts/"] = _ =>
      {
        List<Contact> allContacts = Contact.GetAll();
        return View["view_contacts.cshtml", allContacts];
      };
      Post["/view_contacts/"] = _ =>
      {
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-phoneNumber"], Request.Form["new-address"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["view_contacts.cshtml", allContacts];
      };
      Post["/contacts_deleted"] = _ =>
      {
        Contact.DeleteAll();
        return View["contacts_deleted.cshtml"];
      };
      Get["/contact/new"] = _ =>
      {
        return View["new_contact_form.cshtml"];
      };
      Post["/contact_created"] = _ =>
      {
        Contact newContact = new Contact(Request.Form["new-name"], Request.Form["new-phoneNumber"], Request.Form["new-address"]);
        return View["contact_created.cshtml", newContact];
      };
      Get["/contact_created/{id}"] = parameters =>
      {
        List<Contact> model = new List<Contact> {};
        Contact contact = Contact.Find(parameters.id);
        Contact.Save(contact);
        return View["contact_created.cshtml", contact];
      };
    }
  }
}
