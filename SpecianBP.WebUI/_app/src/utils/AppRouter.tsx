// import { Provider, inject } from 'mobx-react';
// import createBrowserHistory from 'history/createBrowserHistory';
// import { loadavg } from 'os';
// import { RouterModel, Link, ActiveRoute, CurrentRoute, startRouter, Route } from "@st/globster-router";

// export class AppRouter extends RouterModel {

//     /*
//         Root 
//             -Project
//                 -ProjectDetail
//                     -Resources

//                 -ProjectProperties
//     */

//     constructor() {
//         super();
//         let DefaultRedirect = this.redirect(this.Root, this.Projects);
//         () => DefaultRedirect;
//     }

//     Root = this.rootRoute({
//         path: "/",
//     });

//     CurrentUser = this.route(this.Root, {
//         path: "CurrentUser",
//         title: "CurrentUser",
//     });


//     Users = this.route(this.Root, {
//         path: "Users",
//         title: "users",
//     });

//     UserDetail = this.route(this.Users, {
//         path: u => u.userId,
//         title: "user detail",
//         params: {
//             userId: "",
//         }
//     });

//     Projects = this.route(this.Root, {
//         path: "Projects",
//         title: "projects",
//     });

//     ProjectDetail = this.route(this.Projects, {
//         path: p => p.projectId,
//         title: "project detail",
//         params: {
//             projectId: "",
//         }
//     });

//     ProjectSettings = this.route(this.ProjectDetail, {
//         path: "ProjectSettings",
//         title: "project settings",
//         params: {
//             projectId: "",
//         }
//     });

//     ProjectResourceKeys = this.route(this.ProjectDetail, {
//         path: "ProjectResourceKeys",
//         title: "project resource keys editor",
//         params: {
//             projectId: "",
//         }
//     });

//     Resources = this.route(this.ProjectDetail, {
//         path: p => p.langId,
//         title: "ResourceEditor",
//         params: {
//             langId: "",
//             projectId: "",
//         }
//     });

//     redirect(from: Route<any>, to: Route<any>) {
//         from.redirect = () => to;
//     }

// }