
export interface ILanguage {
    id: string;
    locName: string;
    projectId: string;
}

export interface IProject {
    id: string,
    name: string,
    description: string,
    projectLocalizations: ProjectLocalization[]
}

export interface Resource {
    resourceValue: string,
    resourceKeyId: string,
    id?: string,
    localizationId: string
}

export interface ResourceKey {
    id?: string,
    name: string,
    defaultValue: string,
    description: string,
    projectId: string,
}

export interface ResourceKeyTranslation {
    resKeyDefaultValue: string,
    resKeyId: string,
    resourceId?: string,
    resourceValue: string,
    resourceKeyName?: string,
    description?: string
}

export interface User {
    id?: string,
    displayName: string,
    userName: string,
    password: string,
}

export interface DetailedUser extends User {
    projects: IProject[],
    projectLocalizations: ProjectLocalization[],
    userRoles: UserRole[]
}

export interface UserProject{
    projectId: string,
    userId: string,
    project: IProject,
}

export interface UserRole{
    id: string,
    name: string,
    grantsSerialized: string
}

export interface UserUserRole{
    userRoleId: string,
    userId: string,
    userRole: UserRole
}

export interface ProjectLocalization{
    id: string,
    projectId: string,
    locName: string,
    projectName: string,
}

export interface UserProjectLocalization{
    id?: string,
    userId: string,
    projectLocalizationId: string,
    projectLocalization: ProjectLocalization
}

export interface CurrentUser {
    id: string,
    displayName: string,
    userName: string,
    projectLocalizations: ILanguage[],
    //booleans
    isAdmin: boolean,
    canDeleteProject: boolean,
    canCreateProject: boolean,
    canEditProject: boolean,
    canGetProject: boolean,
    canCreateLangOnProject: boolean,
    canEditLangOnProject: boolean,
    canGetLangOnProject: boolean,
    canGetResourceKeys: boolean,
    canEditResourceKeys: boolean,
    canCreateResourceKeys: boolean,
    canDeleteResourceKeys: boolean,
    canGetResources: boolean,
    canEditResources: boolean,
    canExportProject: boolean,
    UserRoles: UserUserRole[]
}

export enum ResourceState {
    Ok, Empty, Error, Edited, InProgress, Active
}

