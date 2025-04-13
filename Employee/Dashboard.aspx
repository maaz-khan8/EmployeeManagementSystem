<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EmployeeManagementSystem.Employee.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Welcome, <asp:Literal ID="litEmployeeName" runat="server"></asp:Literal>!</h2>
        
        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card mb-4">
                    <div class="card-header">
                        <h5>Your Profile</h5>
                    </div>
                    <div class="card-body">
                        <div class="mb-2">
                            <strong>Name:</strong> <asp:Literal ID="litName" runat="server"></asp:Literal>
                        </div>
                        <div class="mb-2">
                            <strong>Email:</strong> <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                        </div>
                        <div class="mb-2">
                            <strong>Department:</strong> <asp:Literal ID="litDepartment" runat="server"></asp:Literal>
                        </div>
                        <div class="mb-2">
                            <strong>Designation:</strong> <asp:Literal ID="litDesignation" runat="server"></asp:Literal>
                        </div>
                        <div class="mb-2">
                            <strong>Joining Date:</strong> <asp:Literal ID="litJoiningDate" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="card-footer">
                        <a href="Profile.aspx" class="btn btn-primary">View Full Profile</a>
                    </div>
                </div>
            </div>
            
            <div class="col-md-8">
                <div class="card mb-4">
                    <div class="card-header">
                        <h5>Company Announcements</h5>
                    </div>
                    <div class="card-body">
                        <asp:Repeater ID="rptAnnouncements" runat="server">
                            <ItemTemplate>
                                <div class="card mb-3">
                                    <div class="card-header d-flex justify-content-between">
                                        <h6><%# Eval("Title") %></h6>
                                        <small>Posted by: <%# Eval("PostedBy") %> on <%# Eval("PostedDate", "{0:MMM dd, yyyy}") %></small>
                                    </div>
                                    <div class="card-body">
                                        <p><%# Eval("Content") %></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        
                        <asp:Panel ID="pnlNoAnnouncements" runat="server" CssClass="alert alert-info" Visible="false">
                            No announcements available.
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
