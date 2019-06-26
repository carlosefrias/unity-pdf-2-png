import pdf2image
from pdf2image import convert_from_path
import os
import sys

def convert(pdf_filepath):
    # get filename andddddd extension from filepath
    filename, file_extension = os.path.splitext(pdf_filepath)
    # Get the images from pdf (one for each page)
    images = pdf2image.convert_from_path(filename + file_extension, fmt='png')
    i = 1
    for image in images:
        image.save(filename + "_" + str(i) + ".png")
        i += 1

file_path = sys.argv[1]
convert(file_path)
print("Done!")