export interface Territory
{
    id: string;
    name: string;
    parent: string;
    territories: Territory[]
}