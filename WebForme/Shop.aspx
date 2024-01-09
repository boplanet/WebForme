<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="WebForme.Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Dodaj proizvod</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblProductName" runat="server" Text="Naziv:"></asp:Label>
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblProductDescription" runat="server" Text="Opis:"></asp:Label>
            <asp:TextBox ID="txtProductDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Spremi" OnClick="btnSave_Click" />
            <br /><br />
            <asp:GridView ID="gridProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="gridProducts_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Naziv" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Opis" SortExpression="Description" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

