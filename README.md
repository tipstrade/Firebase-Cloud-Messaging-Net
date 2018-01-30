# Firebase-Cloud-Messaging-Net
A .Net library for sending Firebase Cloud Messages

Usage example:

```csharp

var notification = new AndroidNotification()
{
    Title = "Notification header",
    Body = "Notification body"
};
var message = new Message<AndroidNotification>()
{
    To = "Device token",
    Notification = notification
};
var response = message.Send("Server key at Settings->Cloud Messaging");
```
