<%@ Page Title="О работе" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Lab5.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2><br />Работу выполнила:</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Студентка:</h3>
        </header>
        <p>
            <span class="label label-default">Группы: ЭиУ 544</span>
            </p>
        <p>
            <span class="label label-default">Кафедры:</span>
            Прикладной информатики</p>
    </section>

    <section class="contact">
        <header>
            <h3>ФИО:</h3>
        </header>
        <p>
            <span class="label label-default">Фамилия:</span>
            <span>Пиджакова</span>
        </p>
        <p>
            <span class="label label-default">Имя:</span>
            Ольга</p>
        <p>
            <span class="label label-default">Отчество: </span>&nbsp;Раушановна</p>
    </section>

    </asp:Content>