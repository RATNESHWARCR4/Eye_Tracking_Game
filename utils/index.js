import bcrypt from "bcryptjs";
import Jwt from "jsonwebtoken";

export const HashPassword = (password) => {
  const salt = bcrypt.genSaltSync(10);
  return bcrypt.hashSync(password, salt);
};

export const VerifyPassword = (password, hashedPassword) => {
  return bcrypt.compareSync(password, hashedPassword);
};

export const VerifyToken = (token) => {
  const data = Jwt.verify(token, process.env.SECRET);
  if (data) {
    return data;
  } else {
    return res.status(401).send("You are not Allowed to access this resource");
  }
};
