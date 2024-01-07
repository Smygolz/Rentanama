import React, { ReactNode } from "react";
import Header from "../header/Header";
import Footer from "../footer/Footer";

interface BaseLayoutProps {
  children: ReactNode;
}
const BaseLayout: React.FC<BaseLayoutProps> = ({ children }) => {
  return (
    <div>
      <Header />
      <div>{children}</div>
      <Footer />
    </div>
  );
};

export default BaseLayout;
