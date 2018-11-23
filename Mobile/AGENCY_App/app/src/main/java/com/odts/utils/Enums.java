package com.odts.utils;

public class Enums {
    //For agency view
    public enum RequestStatusEnum {
        Pending("Chờ Xử lý", 1),
        Processing("Đang xử lý", 2),
        Done("Hoàn thành", 3),
        Cancel("Hủy bỏ", 4),
        New("Tạo mới", 5),
        WaitingCancel ("Chờ hủy", 6);

        private String stringValue;
        private int intValue;

        private RequestStatusEnum(String toString, int value) {
            stringValue = toString;
            intValue = value;
        }

        public String getStringValue() {
            return stringValue;
        }

        public int getIntValue() {
            return intValue;
        }

        @Override
        public String toString() {
            return stringValue;
        }
    }

    //For ITSupporter View
    enum TicketStatusEnum {
        Await("Đang chờ xử lý", 1),
        In_Process("Đang xử lý", 2),
        Done("Hoàn Thành", 3),
        Cancel("Hủy bỏ", 4);

        private String stringValue;
        private int intValue;

        private TicketStatusEnum(String toString, int value) {
            stringValue = toString;
            intValue = value;
        }

        public String getStringValue() {
            return stringValue;
        }

        public int getIntValue() {
            return intValue;
        }

        @Override
        public String toString() {
            return stringValue;
        }
    }

    //For Ticket Task
    enum TicketTaskEnum {
        New("Mới", 1),
        In_Process("Đang xử lý", 2),
        Done("Hoàn thành", 3),
        Cancel("Hủy bỏ", 4);

        private String stringValue;
        private int intValue;

        private TicketTaskEnum(String toString, int value) {
            stringValue = toString;
            intValue = value;
        }

        public String getStringValue() {
            return stringValue;
        }

        public int getIntValue() {
            return intValue;
        }

        @Override
        public String toString() {
            return stringValue;
        }
    }

    enum Gender {
        Male("Nam", 1),
        Female("Nữ", 2),
        Others("Khác", 3);

        private String stringValue;
        private int intValue;

        private Gender(String toString, int value) {
            stringValue = toString;
            intValue = value;
        }

        public String getStringValue() {
            return stringValue;
        }

        public int getIntValue() {
            return intValue;
        }

        @Override
        public String toString() {
            return stringValue;
        }
    }
}



