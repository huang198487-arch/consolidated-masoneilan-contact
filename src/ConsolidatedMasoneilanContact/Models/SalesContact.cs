namespace ConsolidatedMasoneilanContact.Models;

public sealed record SalesContact(
    string Name,
    string Role,
    string DisplayPhone,
    string PhoneUri,
    string Email);
