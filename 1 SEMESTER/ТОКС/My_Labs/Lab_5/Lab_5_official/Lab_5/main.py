
import sys
from PyQt5 import QtWidgets
from PyQt5 import uic
from PyQt5.QtCore import Qt
from time import sleep
from random import randint

import threading

def Next(s):
    sleep(s.delay)
    if s.flag:
        s.sendFrame(None)
    return 0 

class MainWindow(QtWidgets.QMainWindow):

    def setNext(self, next_):
        self.next = next_
        self.thread = threading.Thread(target=Next, args=(self,))

    def __init__(self, title:str, is_monitor:bool, next_, offset):
        self.flag = True
        self.next = next_
        self.temp = None
        self.delay = 3
        self.title= title
        self.is_monitor = is_monitor
        self.frame = [0,0,0,0,0,0,0]
        self.thread = threading.Thread(target=Next, args=(self,))
        super().__init__()
        self.initUI(title, is_monitor, offset)

    def initUI(self, title, is_monitor, offset):
        uic.loadUi("main.ui",self)
        self.btnStart.clicked.connect(self.Start)
        self.btnStart.setVisible(is_monitor)
        self.Marker.setText("")
        self.setWindowTitle(title)
        self.show()
        self.move(offset, 300)

    def sendFrame(self, frame):
        self.Marker.setText(" ")
        #print(self.title,' transmit to: ',self.next.title)

        if self.frame[0] == 'F':
            if self.frame[1] == self.cbSA.currentText():
                self.frame[3] = 1
                if self.temp == None:
                    self.temp = self.frame[2]
                if self.frame[2] == self.temp:
                    self.output.insertPlainText(self.frame[-1])
                else:
                    self.output.insertPlainText('\n')
                    self.output.insertPlainText(self.frame[-1])
                    self.temp = self.frame[2]
                    
            if self.frame[2] == self.cbSA.currentText() and self.frame[1] == self.cbDA.currentText():
                if self.frame[3] == 1:
                    self.frame[0] = 'T'
        if self.frame[0] == 'T':
            text = self.input.text()
            if text.__len__() != 0:
                self.frame[0] = 'F'
                self.frame[1] = self.cbDA.currentText()
                self.frame[2] = self.cbSA.currentText()
                self.frame[3] = 0
                self.frame[4] = self.frame[4]
                self.frame[5] = text[0]
                self.input.setText(text[1:])

        #print(self.frame)
        self.next.getFrame(self.frame)

    def getFrame(self, frame):
        #print(self.title, ' receive : ', frame)
        self.frame = frame
        self.Marker.setText("*")
        if self.frame[0] == 'F':
            if self.is_monitor and self.cbSA.currentText() != frame[1]:
                if self.frame[4] == 0:
                    self.frame[4] = 1
                else:
                    self.frame[4] = 0
                    self.frame[0] = 'T'
                    self.frame[5] = 0

        self.thread._stop()
        self.thread = threading.Thread(target=Next, args=(self,))
        self.thread.start()        
        pass

    def Myclose(self,n):
        self.flag = False
        if n == 0:
            self.next.Myclose(n+1)
            if self.thread.is_alive():
                self.thread.join()
                self.thread._stop()
            
            self.close()
        else:
            if self.thread.is_alive():
                self.thread.join()
                self.thread._stop()
            self.close()

    def keyPressEvent(self, e):
        if e.key() == Qt.Key_Escape:
            self.flag = False
            self.next.Myclose(0)
            if self.thread.is_alive():
                self.thread.join()
                self.thread._stop()            
            self.close()

    def Start(self):
        self.frame = ['T',self.cbDA.currentText(),self.cbSA.currentText(),0,0,0]
        self.sendFrame(self.frame)


if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)

    ex = MainWindow('Monitor', True, None, 700)
    qex2 = MainWindow('Nexus 2', False, ex, 400)
    qex1 = MainWindow('Nexus 1', False, qex2, 1000)
    ex.setNext(qex1)
    
    a = app.exec_()
    sys.exit(a)                