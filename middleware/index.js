import Jwt from "jsonwebtoken";

export const Auth = async (req, res, next) => {
  const data = Jwt.verify(req.headers.authorization, process.env.SECRET);
  if (data) {
    req.user = data;
    next();
  } else {
    return res.status(401).send("You are not Allowed to access this resource");
  }
};
