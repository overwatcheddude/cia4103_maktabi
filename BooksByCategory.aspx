<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="BooksByCategory.aspx.cs" Inherits="BooksByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 20px;
        }
        .auto-style2 {
            width: 101px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        Browse Books By Category</h1>
    <p>
        Choose a category:
        <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
    <asp:DataList ID="dlBooks" runat="server" Width="100%">
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="2">
                        <span class="booktitle">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Title") %>'></asp:Literal>
                         </span>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# "images/"+Eval("coverphoto") %>' Width="90px" />
                    </td>
                    <td><strong>Author:</strong>
                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Author") %>'></asp:Literal>
                        <br />
                        <strong>Year:</strong>
                        <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("Year") %>'></asp:Literal>
                        <br />
                         <ajaxToolkit:Rating ID="Rating1" runat="server" ReadOnly="True" FilledStarCssClass="filled" EmptyStarCssClass="empty" StarCssClass="filled" WaitingStarCssClass="filled" BehaviorID="Rating1_RatingExtender" CurrentRating='<%# Eval("avgRating") %>'>
                        </ajaxToolkit:Rating>
                         Votes (<asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Votes") %>'></asp:Literal>)<br />
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# "BookDetails.aspx?id=" + Eval("BookId") %>' CssClass="more">More Details...</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </p>
</asp:Content>

