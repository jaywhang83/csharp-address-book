using Nancy;
using System;
using AddressBook.Objects;
using System.Collections.Generic;

namespace ContactList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => return View["index.cshmtl"];
    };
    Get["/view_contacts"] = _ =>
    {
      List<Contact> allContacts = Contact.GetAll();
      return View["view_contact.cshtml", allContacts];
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
      Contact newContact = new Contact(Request.Form["new-name"], Request.From["new-phoneNumber"], Reqiest.Form["new-address"]);
      newContact.Save();
      return View["contact_created.cshtml", newContact];
    };
    Get["/contact_created/{id}"] = parameters =>
    {
      Contact contact = Contact.Find(parameters.id)
      return View["contact_created.cshtml", contact];
    };
  }
}
