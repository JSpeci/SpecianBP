import {
    ILanguage, IProject, Resource, ResourceKey, ResourceKeyTranslation,
    ResourceState, DetailedUser, User, CurrentUser, UserProject, ProjectLocalization, UserProjectLocalization, UserRole
} from './interfaces';

//helper object
export class ApiRequest {

    url: string;

    constructor(url: string) {
        this.url = url;
    }

    getHeaders() {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        myHeaders.set("Authorization", "Bearer " + (window as any).restDriverAccessToken);
        return myHeaders;
    }

    getProjects(): Promise<IProject[]> {

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Projects', myInit).then((response) => {

            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getUserById(userId: string): Promise<DetailedUser> {

        console.log("GET: " + userId);

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };
        let url = '/api/Users/detail/' + userId;
        //console.log(url);
        return fetch(url, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getAllUsers(): Promise<DetailedUser[]> {

        console.log("GET: " + "Get users");

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Users', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    /*     logoutCurrentUser() : Promise<any>{
            console.log("LOGOUT: " + "current user");
    
            const myHeaders = new Headers();
            myHeaders.set("Authorization", "Bearer " + (window as any).restDriverAccessToken);
    
            var myInit = {
                method: 'OPTIONS',
                headers: myHeaders
            };
    
            return fetch('account/logout', myInit).then((response) => {
                return response.json();
            }).then((data) => {
                return data;
            });
        } */

    getCurrentUser(): Promise<CurrentUser> {

        console.log("GET: " + "Get users");

        const myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Users/Me', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }


    postNewResource(newResource: Resource): Promise<Resource> {
        console.log("POST: " + JSON.stringify(newResource));

        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'POST',
            body: JSON.stringify(newResource),
            headers: myHeaders
        };

        let error = false;
        let response = fetch('/api/Resources', myInit).then((response) => {
            return response.json();
        }).catch(error => { console.error('Error:', error); error = true; })
            .then(response => {
                return response;
            });

        return response;
    }

    postNewLang(newLang: ProjectLocalization): Promise<ProjectLocalization> {
        console.log("POST: " + JSON.stringify(newLang));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'POST',
            body: JSON.stringify(newLang),
            headers: myHeaders
        };

        return fetch('/api/Localizations', myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("response", JSON.stringify(response));
                return response;
            });
    }

    deleteLang(id: string): Promise<ProjectLocalization> {
        console.log("DELETE: " + JSON.stringify(id));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'DELETE',
            body: "",
            headers: myHeaders
        };

        return fetch('/api/Localizations/' + id, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("response", JSON.stringify(response));
                return response;
            });
    }


    postNewProject(newProject: IProject): Promise<IProject> {
        console.log("POST: " + JSON.stringify(newProject));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'POST',
            body: JSON.stringify(newProject),
            headers: myHeaders
        };

        return fetch('/api/Projects', myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                return response;
            });
    }

    putUser(user: User): Promise<User> {
        console.log("PUT: " + JSON.stringify(user));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'PUT',
            body: JSON.stringify(user),
            headers: myHeaders
        };

        return fetch('/api/Users/' + user.id, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("RESPONSE: " + JSON.stringify(response));
                return response;
            });
    }

    deleteUser(userId: string): Promise<DetailedUser> {
        console.log("DELETE: " + JSON.stringify(userId));

        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'DELETE',
            headers: myHeaders
        };

        return fetch('/api/Users/' + userId, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("RESPONSE: " + JSON.stringify(response));
                return response;
            });
    }

    putProject(project: IProject): Promise<IProject> {
        console.log("PUT: " + JSON.stringify(project));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'PUT',
            body: JSON.stringify(project),
            headers: myHeaders
        };

        return fetch('/api/Projects/' + project.id, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("RESPONSE: " + JSON.stringify(response));
                return response;
            });
    }

    deleteProject(projId: string): Promise<IProject> {
        console.log("DELETE: " + JSON.stringify(projId));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'DELETE',
            headers: myHeaders
        };

        return fetch('/api/Projects/' + projId, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("RESPONSE: " + JSON.stringify(response));
                return response;
            });
    }


    putResource(resource: Resource): Promise<Resource> {
        console.log("PUT: " + JSON.stringify(resource));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'PUT',
            body: JSON.stringify(resource),
            headers: myHeaders
        };

        return fetch('/api/Resources/' + resource.id, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                return response;
            });
    }

    putResourceKey(resourceKey: ResourceKey): Promise<ResourceKey> {
        console.log("PUT: " + JSON.stringify(resourceKey));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'PUT',
            body: JSON.stringify(resourceKey),
            headers: myHeaders
        };

        return fetch('/api/ResourceKeys/' + resourceKey.id, myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                //console.log("RESPONSE: " + JSON.stringify(response));
                return response;
            });
    }

    postNewResourceKey(newResourceKey: ResourceKey): Promise<ResourceKey> {
        console.log("POST: " + JSON.stringify(newResourceKey));


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'POST',
            body: JSON.stringify(newResourceKey),
            headers: myHeaders

        };

        return fetch('/api/ResourceKeys', myInit).then((response) => {
            return response.json();
        }).catch(error => console.error('Error:', error))
            .then(response => {
                return response;
            });
    }

    postResxFileResource(data: FormData, projId: string, langName: string): Promise<any> | null {

        console.log("POST: " + data);

        const myHeaders = new Headers();
        myHeaders.set("Authorization", "Bearer " + (window as any).restDriverAccessToken);

        console.log(myHeaders);

        var myInit = {
            method: 'POST',
            body: data,
            headers: myHeaders
        };

        return fetch('/api/Localizations/byProjectId/' + projId + "?langName=" + langName, myInit).then((response) => {
            return response;
        }).catch(error => console.error('Error:', error));
    }

    postResxFileDefaults(data: FormData, projId: string): Promise<any> | null {

        console.log("POST: " + data);

        const myHeaders = new Headers();
        myHeaders.set("Authorization", "Bearer " + (window as any).restDriverAccessToken);

        console.log(myHeaders);

        var myInit = {
            method: 'POST',
            body: data,
            headers: myHeaders
        };

        return fetch('/api/Localizations/importDefaults/' + projId, myInit).then((response) => {
            return response;
        }).catch(error => console.error('Error:', error));
    }


    // exportProject(projId: string): Promise<any> | null {

    //     console.log("GET: " + "export");

    //     const myHeaders = new Headers();
    //     myHeaders.set("Authorization", "Bearer " + (window as any).restDriverAccessToken);

    //     console.log(myHeaders);

    //     var myInit = {
    //         method: 'GET',
    //         headers: myHeaders
    //     };

    //     return fetch('/UIActions/exportProject/' + projId, myInit).then((response) => {
    //         return response;
    //     }).catch(error => console.error('Error:', error));
    // }

    //Langs are project specific
    getLangsByProjectId(projId: string): Promise<ProjectLocalization[]> {

        var myHeaders = this.getHeaders();
        var myInit = {
            method: 'GET',
            headers: myHeaders
        };


        return fetch('/api/Localizations/byProjectId/' + projId, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getAllResources(): Promise<Resource[]> {


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Resources', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getAllUserRoles(): Promise<UserRole[]> {


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Users/UserRoles', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getResourcesByProjectIdAndLangId(projId: string, locId: string): Promise<ResourceKeyTranslation[]> {


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        let url = '/api/Project/' + projId + '/Resources?localizationId=' + locId;
        return fetch(url, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;

        });
    }

    getResourceKeyById(id: string): Promise<ResourceKey> {


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/ResourceKeys/' + id, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }


    deleteResourceKey(id: string): Promise<ResourceKey> {

        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'DELETE',
            headers: myHeaders
        };

        return fetch('/api/ResourceKeys/' + id, myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }

    getResourceKeysByProjectId(projectId: string): Promise<ResourceKey[]> {


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/Project/' + projectId + '/ResourceKeys', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }


    getResourceKeys(): Promise<ResourceKey[]> {


        var myHeaders = this.getHeaders();

        var myInit = {
            method: 'GET',
            headers: myHeaders
        };

        return fetch('/api/ResourceKeys', myInit).then((response) => {
            return response.json();
        }).then((data) => {
            return data;
        });
    }



}