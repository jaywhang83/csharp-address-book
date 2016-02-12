using System;
using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string Name;
    private string PhoneNumber;
    private string Address;
    private int Id;
    private static List<Contact> Contacts = new List<Contact> {};


    public Contact(string name, string phoneNumber, string address)
    {
      Name = name;
      PhoneNumber = phoneNumber;
      Address = address;
      Contacts.Add(this); 
      Id = Contacts.Count;
    }

    public void SetName(string name)
    {
      Name = name;
    }

    public string GetName()
    {
      return Name;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
      PhoneNumber = phoneNumber;
    }

    public string GetPhoneNumber()
    {
      return PhoneNumber;
    }

    public void SetAddress(string address)
    {
      Address = address;
    }

    public string GetAddress()
    {
      return Address;
    }

    public int GetId()
    {
      return Id;
    }

    public static void Save(Contact contact)
    {
      Contacts.Add(contact);
    }

    public static List<Contact> GetAll()
    {
      return Contacts;
    }

    public static void DeleteAll()
    {
      Contacts.Clear();
    }

    public static Contact Find(int searchId)
    {
      return Contacts[searchId - 1];
    }
  }
}
