interface API {
  QUESTIONS: string;
  PARTICIPANTS: string;
  TOPTEN: string;
}

export const API_ROUTE: API = {
  QUESTIONS: "https://localhost:7219/questions/getall",
  PARTICIPANTS: "https://localhost:7219/participants/getall",
  TOPTEN: "https://localhost:7219/participants/gettop",
};
