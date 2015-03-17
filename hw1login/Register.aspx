<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="hw1login.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <form id="form1" runat="server">
    <div id="platform">
        <p style="text-align: center; height: 40px;">Register </p>
       <div class="tri">
         Username
        </div>
        <div class="tri">
            <input id="UsernameText" type="text" runat="server"/><br />
        </div>
        <div class="require">           
            <asp:Label ID="LabelUsername" runat="server"  Text="" ForeColor="Red"></asp:Label>            
        </div>
        <div class="tri">
            Password  
        </div>
        <div class="tri">
            <input id="PasswordText" type="password" runat="server"/>
        </div>
        <div class="require">
            
            <asp:Label ID="LabelPassword" runat="server" Text="" ForeColor="Red"></asp:Label>
            
        </div>
        <div class="tri">
            
        </div>           
        <div class="tri">
            <asp:Button ID="Submit" runat="server" Text="Register" OnClick="Submit_Click" />     
        </div>        

                           

        <asp:SqlDataSource ID="UserData" runat="server" 
            ConnectionString="<%$ ConnectionStrings:hw1login_dbConnectionString %>" 
            DeleteCommand="DELETE FROM [Users] WHERE [Username] = @Username" 
            InsertCommand="INSERT INTO [Users] ([Username], [Password]) VALUES (@Username, @Password)" 
            SelectCommand="SELECT * FROM [Users] WHERE ([Username] = @Username)" 
            UpdateCommand="UPDATE [Users] SET [Password] = @Password WHERE [Username] = @Username" 
            OnSelecting="UserData_Selecting">

            <DeleteParameters>
                <asp:Parameter Name="Username" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Username" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter Name="Username" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Username" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </form>

</body>
</html>
