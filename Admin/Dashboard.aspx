<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EmployeeManagementSystem.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Admin Dashboard</h2>
        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card bg-primary text-white mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Total Employees</h5>
                        <h2 class="display-4"><asp:Literal ID="litTotalEmployees" runat="server"></asp:Literal></h2>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card mb-4">
                    <div class="card-header">
                        <h5>Department Distribution</h5>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="gvDepartments" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Department" HeaderText="Department" />
                                <asp:BoundField DataField="Count" HeaderText="Number of Employees" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <div class="card mb-4">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h5>Company Announcements</h5>
                        <button type="button" class="btn btn-primary btn-sm" data-bs-toggle="modal" data-bs-target="#announcementModal">
                            Add Announcement
                        </button>
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
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Announcement Modal -->
    <div class="modal fade" id="announcementModal" tabindex="-1" aria-labelledby="announcementModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="announcementModalLabel">Add New Announcement</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <asp:Label ID="lblTitle" runat="server" CssClass="form-label" Text="Title"></asp:Label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblContent" runat="server" CssClass="form-label" Text="Content"></asp:Label>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnAddAnnouncement" runat="server" Text="Add Announcement" CssClass="btn btn-primary" OnClick="btnAddAnnouncement_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
