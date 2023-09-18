import { Roles } from "./roles";
import { Stats } from "./stats";
import { Power } from "./power";

export interface Hero {
    id: number;
    name: string;
    power: string;
    backstory: string;
    photoUrl: string;
    image: string;
    source: string;
    attribute: string;
    attackType: string;
    complexity: string;
    roles: Roles;
    stats: Stats;
    powerList: Power[];
  }