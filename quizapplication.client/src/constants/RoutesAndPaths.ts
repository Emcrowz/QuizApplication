interface API {
  QUESTIONS: string;
  PARTICIPANTS: string;
  TOPTEN: string;
}

export const API_ROUTE: API = {
  QUESTIONS: "http://localhost:5170/questions/getall",
  PARTICIPANTS: "http://localhost:5170/participants/getall",
  TOPTEN: "http://localhost:5170/participants/gettop",
};
